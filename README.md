#CICD Process

1. On push to master the CI build "VogCodeChallenge.API - CI" is ran
  * Creates a docker image
  * Pushes docker image to AWS ECR tagged with the buildid (not build number)
  * Produces a ECSTaskDefinition build artifact
2. On completion of the CI build the CD pipeline "VogCodeChallenge.API - Deploy" is ran
  * Adds new revision of the ECS task definition to ECS
  * Forces Environment to load new revision  

 #Database Connectivity
 true/false value of Appsetting/Environment variable EnableDBConnectivity 

