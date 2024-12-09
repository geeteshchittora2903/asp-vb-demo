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
                    // Allow exit codes 0 and 1 as success
                    def returnCode = bat returnStatus: true, script: """
                    robocopy "${sourceDir}" "${targetDir}" *.vb *.asp /E /Z /COPY:DAT /R:3 /W:5
                    """

                    if (returnCode > 1) {
                        error "Robocopy failed with exit code ${returnCode}"
                    } else {
                        echo "Robocopy completed successfully with exit code ${returnCode}"
                    }

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
