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
                    def sourceDir = "${env.WORKSPACE}" // Local workspace
                    def targetDir = "C:/Jenkins/Deployment" // Target deployment directory

                    echo "Source Directory: ${sourceDir}"
                    echo "Target Directory: ${targetDir}"

                    // Ensure target directory exists
                    bat """
                    if not exist "${targetDir}" mkdir "${targetDir}"
                    """

                    // Dynamically define the list of files to deploy
                   // def filesToDeploy = [
                     //   "${sourceDir}\\folder1\\demo1.vb",
                       // "${sourceDir}\\folder2\\sample2.vb",
                       // "${sourceDir}\\folder2\\sample3.vb"
                 //   ]

                    // Deploy files one by one
                    filesToDeploy.each { filePath ->
                        def fileName = filePath.tokenize("\\").last() // Extract file name
                        echo "Deploying file: ${fileName}"

                        bat """
                        xcopy "${filePath}" "${targetDir}" /Y
                        """
                    }

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
