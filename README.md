1.  Frontend
-	cd C:\repositories\GitHubUser1111111\projectfabric\src\ProjectFabric.Razor
-	npx tailwindcss -i .\Styles\tailwind.css -o ..\ProjectFabric.Blazor.Wasm\wwwroot\css\app.css
2.  Backend
3.  Storages
4.  Infrastructure
-   install AzureCLI
        Invoke-WebRequest -Uri https://aka.ms/installazurecliwindows -OutFile .\AzureCLI.msi; Start-Process msiexec.exe -Wait -ArgumentList '/I AzureCLI.msi /quiet'; rm .\AzureCLI.msi
-   login to Azure CLI
        az login
-   select subscription
        az account set --subscription "886d1919-ecbc-463f-b592-e92ceb03d1c1"
-   create service principal
        az ad sp create-for-rbac --role="Contributor" --scopes="/subscriptions/886d1919-ecbc-463f-b592-e92ceb03d1c1"
-   set your environment variables
        $ $Env:ARM_CLIENT_ID = "<APPID_VALUE>"
        $ $Env:ARM_CLIENT_SECRET = "<PASSWORD_VALUE>"
        $ $Env:ARM_SUBSCRIPTION_ID = "<SUBSCRIPTION_ID>"
        $ $Env:ARM_TENANT_ID = "<TENANT_VALUE>"
-   create a folder
        New-Item -Path "C:\repositories\GitHubUser1111111\projectfabric" -Name "infrastructure" -ItemType "directory"
-   create main.tf
-   set working directory
        cd C:\repositories\GitHubUser1111111\projectfabric\infrastructure
-   initialize Terraform
        terraform init
-   format and validate the configuration
        terraform fmt
        terraform validate
-   apply your Terraform Configuration
        terraform apply
-   inspect your state
        terraform show
-   to review the information in your state file, use the state command
        terraform state list