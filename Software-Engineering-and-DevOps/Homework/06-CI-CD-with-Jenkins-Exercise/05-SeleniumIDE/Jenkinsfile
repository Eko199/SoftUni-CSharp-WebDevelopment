pipeline {
    agent any

    environment {
        CHROME_VERSION = '130.0.6723.70'
        CHROMEDRIVER_VERSION = '130.0.6723.70'
        CHROME_INSTALL_PATH = 'C:\\Program Files\\Google\\Chrome\\Application'
        CHROMEDRIVER_PATH = 'C:\\Program Files\\Google\\Chrome\\Application\\chromedriver.exe'
    }

    stages {
        stage('Checkout code') {
            steps {
                git branch: 'main', url: 'https://github.com/Eko199/Jenkins-Exercises.git'
            }
        }
        // stage('Set up .NET Core') {
        //     steps {
        //         bat '''
        //         echo Installing .NET SDK 8.0
        //         choco install dotnet-sdk -y --version=8.0.400
        //         '''
        //     }
        // }
        stage('Restore dependencies') {
            steps {
                bat 'dotnet restore SeleniumIde.sln'
            }
        }
        stage('Build') {
            steps {
                bat 'dotnet build SeleniumIde.sln --configuration Release'
            }
        }
        stage('Run tests') {
            steps {
                bat 'dotnet test SeleniumIde.sln --logger "trx;LogFileName=TestResult.trx"'
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: '**/TestResults/*.trx', allowEmptyArchive: true
            junit '**/TestResults/*.trx'
        }
    }
}