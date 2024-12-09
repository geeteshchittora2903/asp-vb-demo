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
                    def sourceDir = "${env.WORKSPACE}" // Source directory
                    def targetDir = "C:/Jenkins/Deployment" // Target directory
                    
                    echo "Source Directory: ${sourceDir}"
                    echo "Target Directory: ${targetDir}"

                    // Create the target directory if it doesn't exist
                    bat """
                    if not exist "${targetDir}" mkdir "${targetDir}"
                    """

                    // Compare files and copy updated ones
                    echo "Copying updated files..."
                    bat """
                    for %%F in (${sourceDir}\\*.vb ${sourceDir}\\*.asp) do (
                        if not exist "${targetDir}\\%%~nxF" (
                            copy "%%F" "${targetDir}"
                        ) else (
                            for /f %%I in ('certutil -hashfile "%%F" SHA256') do set HASH1=%%I
                            for /f %%J in ('certutil -hashfile "${targetDir}\\%%~nxF" SHA256') do set HASH2=%%J
                            if not "!HASH1!"=="!HASH2!" (
                                copy "%%F" "${targetDir}"
                            )
                        )
                    )
                    """

                    echo 'Deployment Completed.'
                }
            }
        }
    }
}
