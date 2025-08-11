pipeline {
    agent any
    environment{
        IMG_NAME="socialapp"
        IMG_TAG="1.0"
        DOCKER_USER="helix1498"
    }
    stages{
        stage("build"){
            steps{
                echo "Building Docker Artifact..."
                bat 'docker build -t %DOCKER_USER%/%IMG_NAME%:%IMG_TAG% .'
                echo "Docker Artifact Created."
            }
        }
        stage("test"){
            steps{
                echo "Testing Artifact..."
                echo "Creating Docker Container..."
                bat 'docker-compose up -d'
                bat 'docker ps'
                bat 'docker-compose down'
                echo "Test Complete."
            }
        }
        stage("deploy"){
            steps{
                echo "Deploying to DockerHub..."
                withCredentials([usernamePassword(credentialsId:'HelixDockerHubCreds', usernameVariable: 'DOCKER_USER', passwordVariable: 'DOCKER_PASS')]){
                    bat 'docker login -u %DOCKER_USER% -p %DOCKER_PASS%'
                    bat 'docker push %DOCKER_USER%/%IMG_NAME%:%IMG_TAG%'
                    bat 'docker logout'
                }
                echo "Successfully Pushed."
                echo "End of Pipeline."
            }
        }
    }
}