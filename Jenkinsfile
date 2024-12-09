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
                    def targetDir = "C:/Jenkins/Deployment" // Adjust the target directory path

                    echo "Source Directory: ${sourceDir}"
                    echo "Target Directory: ${targetDir}"

                    // Ensure the target directory exists
                    bat """
                    if not exist "${targetDir}" mkdir "${targetDir}"
                    """

                    // Recursively copy all files and folders
                    // Update files and create directories as needed
                    bat """
                    robocopy "${sourceDir}" "${targetDir}" *.vb *.asp /E /Z /COPYALL /R:3 /W:5
                    """

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
