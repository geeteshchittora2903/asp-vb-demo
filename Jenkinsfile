pipeline {
    agent {
        label 'agent19281'
    }  
    stages {  
        stage('Build') {
            steps {
                echo 'Building...'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing...'
            }
        }
        stage('Deploy') {
            steps {
                script {
                    echo 'Deploying to local system...'
                    
                    // Define source and target directories
                    def sourceDir = "${env.WORKSPACE}" // This is the local workspace where the repo is cloned
                    def targetDir = "C:/Jenkins/Deployment"// Adjust the target directory path
                    
                    echo "Source Directory: ${sourceDir}"
                    echo "Target Directory: ${targetDir}"

                    // Create the target directory if it doesn't exist
                    bat """
                    if not exist "${targetDir}" mkdir "${targetDir}"
                    """

                    // Copy files to the target directory
                    bat """
                    xcopy "${sourceDir}\\*.vb" "${targetDir}" /E /I /Y
                    xcopy "${sourceDir}\\*.asp" "${targetDir}" /E /I /Y
                    """

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
