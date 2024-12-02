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

                    // Create the target directory if it doesn't exist
                    bat """
                    if not exist "${targetDir}" mkdir "${targetDir}"
                    """

                    // Get the list of changed files from the last commit
                    def changedFiles = bat(script: 'git diff --name-only HEAD~1 HEAD', returnStdout: true).trim()

                    echo "Changed files: ${changedFiles}"

                    // Loop through the changed files and deploy only the relevant ones
                    changedFiles.split('\n').each { file ->
                        // Generate full target file path
                        def targetFile = "${targetDir}\\${file}"

                        // Create the necessary directories in the target if they don't exist
                        def fileDir = file.replaceAll('[^/]+$', '') // Get the directory path (remove filename)
                        def targetSubDir = "${targetDir}\\${fileDir}"

                        // Create the directory if it does not exist
                        bat """
                        if not exist "${targetSubDir}" mkdir "${targetSubDir}"
                        """

                        // Deploy the file
                        echo "Deploying ${file} to ${targetFile}"
                        bat """
                        xcopy /Y "${sourceDir}\\${file}" "${targetFile}"
                        """
                    }

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
