   M S B A M L   `   `   `  ????K  GMobileConnection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:MobileConnection.Pages.AdminMobileConnection.Pages.Admin  5      /    )MobileConnection.Pages.Admin.EmployeePage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:MobileConnection.Pages.Admin     5        N? 
Background
  ????? N? Title$ EmployeePage??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      ?? 5      $??30 ?6   ?? 5      $??30 ?6   ?? 5      $??30 ?6   ?? 5      $??30 ?6   ?? 5      $??30 ?6   ?? 5      $??30 ?6   ?? 5      $??50 ?6   .+?5   
   ?  ? ColumnDefinitions 5      ?? 5      ?? 5      $	??100 ?6#   .+?5      ?? -   5         ??Name$ 	txbSearch??5       ?? TextWrapping$
 Wrap=?6)   $??10,10,10,10q?6=   ?? 5      -   5        $??1??5      $??
Поиск??6%   $??10,10,10,10q?66   6K   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$	 dtg??5!      $??1??6       AutoGenerateColumns$ False??6-      Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Фамилия??5&      
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 5'      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5(      ??  ?? Path$ Employee_Surname? ?? UpdateSourceTrigger$ PropertyChanged=?  5+      $	 Имя??5,      $
 * 5-       5.      ?? $ Employee_Name?$ PropertyChanged=?  51      $	 Отчество??52      $
 * 53       54      ?? $ Employee_Patronymic?$ PropertyChanged=?  57      $	 Email??58      $
 * 59       5:      ?? $ Employee_Email?$ PropertyChanged=?  5=      $	 Пароль??5>      $
 * 5?       5@      ?? $ Password?$ PropertyChanged=?  5C      $	 Должность??5D      $
 * 5E       5F      ?? $ Post.Post_Name?$ PropertyChanged=?5I      ? 5K   
   $??2??6    5L      ?? 5M      ?? 5N      .+?5P      ?? $??Фамилия??6   $??Right=?6&   $??0,0,10,0q?6B   $??Center=?6T   ?? 5Q      -   5        $ 
tbxSurname??5Q      $??1??6*   $
 Wrap=?6;   5R      ? 5T   
   $??3??6    5U      ?? 5V      ?? 5W      .+?5Y      ?? $??Имя??6   $??Right=?6"   $??0,0,10,0q?6>   $??Center=?6P   ?? 5Z      -   5        $ tbxName??5Z      $??1??6'   $
 Wrap=?67   5[      ? 5]   
   $??4??6    5^      ?? 5_      ?? 5`      .+?5b      ?? $??Отчество??6   $??Right=?6'   $??0,0,10,0q?6C   $??Center=?6U   ?? 5c      -   5        $ tbxPatronymic??5c      $??1??6-   $
 Wrap=?6=   5d      ? 5f   
   $??5??6    5g      ?? 5h      ?? 5i      .+?5k      ?? $??Email??6   $??Right=?6$   $??0,0,10,0q?6@   $??Center=?6R   ?? 5l      -   5        $ tbxEmail??5l      $??1??6(   $
 Wrap=?68   5m      ? 5o   
   $??6??6    5p      ?? 5q      ?? 5r      .+?5t      ?? $??Пароль??6   $??Right=?6%   $??0,0,10,0q?6A   $??Center=?6S   G? 5u      -   5         G?Name$ tbxPassword??5u      $??1??6/   5v      ? 5x   
   $??7??6    5y      ?? 5z      ?? 5{      .+?5}      ?? $??Должность??6   $??Right=?6(   $??0,0,10,0q?6D   $??Center=?6V   ?? 5~      -	   5         ??Name$ cmbPosts??5~       ?? DisplayMemberPath$ 	Post_Name??6)   $??1??6G   5      ? 5?   
   $??10??6    5?      ?? 5?      $	??100 ?6#   ?? 5?      ?? 5?      ?? 5?      .+?5?      ?? -
   5        $??
Назад??5?      $??10,10,10,10q?6%   6:   ?? 5?      -   5        $??Добавить??5?      $??10,10,10,10q?6(   $??1??6=   6M   ?? 5?      -   5        $??Изменить??5?      $??10,10,10,10q?6(   $??2??6=   6M   ?? 5?      -   5        $??Удалить??5?      $??10,10,10,10q?6'   $??3??6<   6L   5?      5?      5?      