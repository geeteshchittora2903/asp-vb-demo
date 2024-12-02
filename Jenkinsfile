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
                    def sourceDir = "${env.WORKSPACE}/https://github.com/geeteshchittora2903/asp-vb-demo.git" // Adjust the source directory path
                    def targetDir = "C:/" // Adjust the target directory path
                    
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
