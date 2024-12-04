pipeline {
    agent {
        label 'agent19281'
    }
    triggers {
        // Polling SCM every minute to check for changes
        pollSCM('* * * * *') 
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

                    // Create the target directory if it doesn't exist
                    bat """
                    if not exist "${targetDir}" mkdir "${targetDir}"
                    """

                    // Get a list of files that have been updated
                    def modifiedFiles = bat(script: 'git ls-tree -r HEAD --name-only', returnStdout: true).trim()

                    echo "Modified files: ${modifiedFiles}"

                    // Loop through the modified files and deploy only the relevant ones
                    modifiedFiles.split('\n').each { file ->
                        // Get the file's target directory
                        def targetFileDir = "${targetDir}\\${file}"

                        // Create the necessary directories in the target if they don't exist
                        def fileDir = file.replaceAll('[^/]+$', '') // Get the directory path (remove filename)
                        def targetSubDir = "${targetDir}\\${fileDir}"
                        
                        // Create the directory if it does not exist
                        bat """
                        if not exist "${targetSubDir}" mkdir "${targetSubDir}"
                        """

                        // Deploy the file
                        echo "Deploying ${file} to ${targetDir}\\${file}"
                        bat """
                        xcopy "${sourceDir}\\${file}" "${targetDir}\\${file}" /Y
                        """
                    }

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
