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
                    def sourceDir = "${env.WORKSPACE}" // Local workspace where the repo is cloned
                    def targetDir = "C:/Jenkins/Deployment" // Target deployment directory
                    
                    echo "Source Directory: ${sourceDir}"
                    echo "Target Directory: ${targetDir}"

                    // Create the target directory if it doesn't exist
                    bat """
                    if not exist "${targetDir}" mkdir "${targetDir}"
                    """

                    // Get the list of changed files from the last commit
                    def changedFiles = bat(script: 'git diff --name-only HEAD~1 HEAD', returnStdout: true).trim()

                    echo "Changed files: ${changedFiles}"

                    // Loop through the changed files and deploy only the relevant ones
                    def files = changedFiles.split('\n')  // Split by line to get each file
                    files.each { file ->
                        // Ensure file path is not empty
                        if (file.trim()) {
                            def sourceFile = "${sourceDir}\\${file}"
                            def targetFile = "${targetDir}\\${file}"

                            // Create the directory structure in target if not already there
                            def targetSubDir = targetFile.substring(0, targetFile.lastIndexOf('\\'))
                            bat """
                            if not exist "${targetSubDir}" mkdir "${targetSubDir}"
                            """

                            // Deploy the file
                            echo "Deploying ${sourceFile} to ${targetFile}"
                            bat """
                            xcopy /Y "${sourceFile}" "${targetFile}"
                            """
                        }
                    }

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
