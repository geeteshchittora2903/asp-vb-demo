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
                    echo 'Deploying only updated files to local system...'
                    
                    // Define source and target directories
                    def sourceDir = "${env.WORKSPACE}" // This is the local workspace where the repo is cloned
                    def targetDir = "C:/Jenkins/Deployment" // Adjust the target directory path
                    
                    echo "Source Directory: ${sourceDir}"
                    echo "Target Directory: ${targetDir}"

                    // Get a list of files that have been updated
                    def modifiedFiles = bat(script: 'git ls-tree -r HEAD --name-only', returnStdout: true).trim().split('\n')

                    echo "Modified files: ${modifiedFiles}"

                    // Loop through the modified files and deploy only the relevant ones
                    modifiedFiles.each { file ->
                        // Skip files if they are directories or not part of the target
                        if (!file.endsWith('/') && (file.startsWith('Folder1/') || file.startsWith('Folder2/'))) {
                            def sourceFilePath = "${sourceDir}\\${file}"
                            def targetFilePath = "${targetDir}\\${file}"

                            // Create necessary directories in the target if they don't exist
                            def targetDirPath = targetFilePath.replaceAll(/[^\\]+$/, '') // Extract directory part from the file path
                            bat """
                            if not exist "${targetDirPath}" mkdir "${targetDirPath}"
                            """
                            
                            // Deploy the file
                            echo "Deploying ${file} to ${targetFilePath}"
                            bat """
                            xcopy "${sourceFilePath}" "${targetFilePath}" /Y
                            """
                        }
                    }

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
