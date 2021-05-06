pipeline {
  agent any
  environment {
      DOCKER_REGISTRY_HOSTNAME = "${TCR_REGISTRY_HOSTNAME}"
      DOCKER_REGISTRY_CREDENTIAL = "${TCR_REGISTRY_CREDENTIAL}"
      DOCKER_REPOSITORY_NAME = "${TCR_NAMESPACE_NAME}/${TCR_REPOSITORY_NAME}"
      IMAGE_NAME = "${env.GIT_LOCAL_BRANCH}-${env.GIT_COMMIT_SHORT}"
    }
  stages {
    stage('检出') {
      steps {
        checkout([
          $class: 'GitSCM', 
          branches: [[name: GIT_BUILD_REF]],
          userRemoteConfigs: [[
            url: GIT_REPO_URL,
            credentialsId: CREDENTIALS_ID
          ]]])
        }
      }
      stage('构建镜像') {
        steps {
          sh "docker build -f UI.Dockerfile --build-arg VUE_APP_API_URL=/api -t ${DOCKER_REPOSITORY_NAME}:${IMAGE_NAME} Blog.UI"
          sh "docker tag ${DOCKER_REPOSITORY_NAME}:${IMAGE_NAME} ${DOCKER_REPOSITORY_NAME}:latest"
        }
      }
      stage('推送镜像') {
        steps {
          script {
            docker.withRegistry("https://${DOCKER_REGISTRY_HOSTNAME}", "${DOCKER_REGISTRY_CREDENTIAL}") {
              docker.image("${DOCKER_REPOSITORY_NAME}:${IMAGE_NAME}").push()
              docker.image("${DOCKER_REPOSITORY_NAME}:latest").push()
            }
          }

        }
      }
    }
  }