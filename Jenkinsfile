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

                    // Create the target directory if it doesn't exist
                    bat """
                    if not exist "${targetDir}" mkdir "${targetDir}"
                    """

                    // Deploy 1 file from folder1 and 2 files from folder2
                    // Adjust file paths for the files you need to deploy
                    bat """
                    xcopy "${sourceDir}\\folder1\\demo1.vb" "${targetDir}" /Y
                    xcopy "${sourceDir}\\folder2\\sample2.vb" "${targetDir}" /Y
                    xcopy "${sourceDir}\\folder2\\sample3.vb" "${targetDir}" /Y
                    """

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
