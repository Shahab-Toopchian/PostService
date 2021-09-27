# PostService

#How to dockerize webapi project
1.create dockerfile with specific configuration
2.docker built -t /your docker hub address/
3.docker run -p 8080:80 -d /your docker hub address/
4.docker push /your docker hub address/

#How to apply dockerfile with kubernetes
1.create .yaml file with specific configuration
2.kubectl apply -f .yaml

#Create NodePort for test 
1.create .yaml file with specific configuration for NodePort
2.Get valid port for nodePort with "kubectl get services"
