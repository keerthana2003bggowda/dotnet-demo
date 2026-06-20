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

        stage('Deploy') {
            steps {
                sh 'dotnet publish HelloApi/HelloApi.csproj -o ./publish'
                sh 'fuser -k 5000/tcp 2>/dev/null || true'
                sh 'sleep 2'
                sh 'nohup dotnet ./publish/HelloApi.dll --urls http://0.0.0.0:5000 > app.log 2>&1 & disown'
                sh 'sleep 5'
                sh 'cat app.log'
                
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