pipeline {
    agent {
        label 'agent19281'
    }
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
                    echo 'Deploying to CIFS share...'

                    // Define source directory and network share details
                    def sourceDir = "${env.WORKSPACE}" // Jenkins workspace containing the files
                    def sharePath = "\\\\191.11.100.122\\geetesh" // CIFS share path
                    def username = "geetesh.chittora" // CIFS username
                    def password = "Espl@2024" // Replace with actual password

                    echo "Source Directory: ${sourceDir}"
                    echo "Target CIFS Share: ${sharePath}"

                    // Map the network drive
                    bat """
                    net use Z: ${sharePath} /C:${ geetesh.chittora } ${Espl@2024 } /PERSISTENT:NO
                    """

                    // Copy files to the network drive
                    bat """
                    xcopy "${sourceDir}\\*.vb" Z:\\ /E /I /Y
                    xcopy "${sourceDir}\\*.asp" Z:\\ /E /I /Y
                    """

                    // Unmap the network drive
                    bat """
                    net use Z: /DELETE
                    """

                    echo 'Deployment to CIFS share completed.'
                }
            }
        }
    }






