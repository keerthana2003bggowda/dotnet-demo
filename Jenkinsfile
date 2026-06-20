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