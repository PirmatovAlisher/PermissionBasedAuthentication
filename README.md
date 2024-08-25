In this project I have tested the availability of Dynamic Authorization in ASP.Net MVC project.

First I created table of Categories with corresponding Products, then on top of their Controllers I implemented [DynamicAuthorization] attribute.

The aim of this project was to create Controllers through them Admin could have control of :

1. Adding/Removing Roles;
2. Assigning roles to user and removing as well;
3. Restricting access for Controllers to particular roles;






 Category List page :

![image](https://github.com/user-attachments/assets/ed12e06e-fd5b-467b-93cf-0ee2c95adaf7)




Product List page :

![image](https://github.com/user-attachments/assets/0f20b2c2-ae9c-4796-8500-a545737859f0)




User List page: Trhough this page we can go to see what Roles are assigned to User and edit it.

![image](https://github.com/user-attachments/assets/1708ae92-385c-48a8-8d9b-2c3b3b02840b)





Role List page : Trhough this page we can go to see what Controller are assigned to particular Role.

![image](https://github.com/user-attachments/assets/4b36323d-c4e5-4350-81fb-fd38f1f0c8f5)




Controller List page: Trhough this page we can go to see what Roles are assigned to particular Controller and edit it.

![image](https://github.com/user-attachments/assets/a55c7d76-8908-4e14-bc6f-662b37877418)


As an example we see that Category Controller visible for three users who has at least one of these roles:

![image](https://github.com/user-attachments/assets/c31e6edc-4de5-4f1f-95cc-7fef5036c859)

Now we will remove Admin role from Category Controller and try to accsess to it :

![image](https://github.com/user-attachments/assets/36131cf5-c46f-401e-8ce0-411ddfbcd3ab)


As we can see Categort Controller restricts users who does not have Public and Member roles:

![image](https://github.com/user-attachments/assets/2a5e7096-1200-4108-8590-f3aa4430aec0)




Conclusion:

Dynamic Authorization makes able to control who can access to the page who can not. It is very useful in that case where the owner of business does not Roles exactly and it changes frequently, so it makes web site flexable.
