pipeline {
    agent { label 'dotnet' }
    environment {
        PATH = "/usr/bin:${env.PATH}"
    }

    stages {

        stage('Checkout') {
            steps {
                git branch: 'main',
                    credentialsId: 'github-pat',
                    url: 'https://github.com/keerthana2003bggowda/dotnet-demo.git'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build HelloApi.sln'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test HelloApi.Tests/HelloApi.Tests.csproj'
            }
        }

        stage('SonarQube Analysis') {
            steps {
                withSonarQubeEnv('sonarqube') {
                    sh "${tool('sonar-scanner')}/bin/sonar-scanner"
                }
            }
        }
        stage('Publish to JFrog') {
            steps {
                withCredentials([usernamePassword(
                    credentialsId: 'artifactory-creds',
                    usernameVariable: 'JFROG_USER',
                    passwordVariable: 'JFROG_TOKEN'
                )]) {
                    sh '''
                        zip -r dotnet-demo-${BUILD_NUMBER}.zip publish/

                        curl -u $JFROG_USER:$JFROG_TOKEN \
                        -T dotnet-demo-${BUILD_NUMBER}.zip \
                        "http://13.201.51.61:8082/artifactory/dotnet-artifacts/dotnet-demo-${BUILD_NUMBER}.zip"
                    '''
                }
            }
        }

        stage('Deploy') {
            steps {
                sh 'nohup dotnet publish/HelloApi.dll --urls http://0.0.0.0:5000 &'
        }
}
    }

    post {
        success {
            echo 'Pipeline succeeded!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}