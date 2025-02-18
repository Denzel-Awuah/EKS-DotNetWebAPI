## .NET 8 Web API AWS System with EKS, EC2, SQS, Lambda and S3
A .NET 8 Web API that Produces messages and sends them to an SQS Queue. The messages in the SQS queue are then consumed by an AWS .NET Lambda function that processes the messages and stores updates into an S3 bucket.

## Deployment 
The .NET Web API application was containerized using Docker, then the image is pushed to a repository in Elastic Container Registry. The image was then pulled from ECR and deployed to Amazon Elastic Kubernetes Services (EKS).
The .NET Web API image pulled from ECR was deployed to a managed nodegroup within Elastic Kubernetes Service using AWS EC2 Instances. A Load Balancer was also deployed to balance the traffic coming into the cluster.


## Deployment Strategy
![Application](/AWS-EKS-DotNet-System-Infrastructure.jpg)
