
所有命令都是在 `Blog.EFCore.Migrations`目录下执行的（Nuget需设置默认项目为它）

如果不是在此目录执行，则需要添加以下参数：
```shell
-s Blog.EFCore.Migrations -p Blog.EFCore.Migrations
```

## 添加迁移

### Nuget

```shell
Add-Migration 迁移名称 -Args "连接字符串"
```

**注意空格问题，如果是有空格就会被识别成两个参数**

### Dotnet tool

```shell
dotnet ef migrations add 迁移名称 -- "连接字符串"
```

## 删除迁移

###Nuget

```shell
Remove-Migration -Args "连接字符串"
```

### Dotnet tool

```shell
dotnet ef migrations remove -- "连接字符串"
```

## 应用迁移

### Nuget

```shell
Update-Database -Args "连接字符串"
```

### Dotnet tool

```shell
dotnet ef database update -- "连接字符串"
```