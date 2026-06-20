pipeline {
    agent { label 'dotnet' }

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

        stage('Deploy') {
            steps {
                sh 'pkill -f "dotnet HelloApi.dll" || true'
                sh 'nohup dotnet publish/HelloApi.dll --urls http://0.0.0.0:5000 > app.log 2>&1 &'
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