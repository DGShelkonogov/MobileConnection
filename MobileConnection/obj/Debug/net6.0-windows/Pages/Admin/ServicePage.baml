   M S B A M L   `   `   `  ????K  GMobileConnection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:MobileConnection.Pages.AdminMobileConnection.Pages.Admin  5      .    (MobileConnection.Pages.Admin.ServicePage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:MobileConnection.Pages.Admin     5        N? 
Background
  ????? N? Title$ ServicePage??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??50 ?6   .+?5   
   ?  ? ColumnDefinitions 5      ?? 5      ?? 5      $	??100 ?6#   .+?5      ?? -   5         ??Name$ 	txbSearch??5       ?? TextWrapping$
 Wrap=?6)   $??10,10,10,10q?6=   ?? 5      -   5        $??1??5      $??
Поиск??6%   $??10,10,10,10q?65   6J   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dtg??5      $??1??6       AutoGenerateColumns$ False??6-      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Наименование??5$      
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 5%      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5&      ??  ?? Path$ Service_Name? ?? UpdateSourceTrigger$ PropertyChanged=?  5)      $	 Статус??5*      $
 * 5+       5,      ?? $ Service_Status?$ PropertyChanged=?  5/      $	 Стоимость??50      $
 * 51       52      ?? $
 Cost?$ PropertyChanged=?  55      $	 Сотрудник??56      $
 * 57       58      ?? $ Employee.Employee_Name?$ PropertyChanged=?5;      ? 5=   
   $??2??6    5>      ?? 5?      ?? 5@      .+?5B      ?? $??Наименование??6   $??Right=?6+   $??0,0,10,0q?6G   $??Center=?6Y   ?? 5C      -   5        $ txbService_Name??5C      $??1??6/   $
 Wrap=?6?   5D      ? 5F   
   $??3??6    5G      ?? 5H      ?? 5I      .+?5K      ?? $??Статус??6   $??Right=?6%   $??0,0,10,0q?6A   $??Center=?6S   ?? 5L      -   5         ??Name$ cmbStatuses??5L   '   $??1??6   .@?5M      ?? 
 ? Tag$
 true??6   .??5N      ?? $??Активна??6   5O      ?? 5P      $ false??6    .??5Q      ?? $??Не активна??6   5R      5S      5T      ? 5V   
   $??4??6    5W      ?? 5X      ?? 5Y      .+?5[      ?? $??Стоимость??6   $??Right=?6(   $??0,0,10,0q?6D   $??Center=?6V   ?? 5\      -   5        $ txbCost??5\   :   $??1??6   $
 Wrap=?6&   6:   5]      ? 5_   
   $??5??6    5`      ?? 5a      ?? 5b      .+?5d      ?? $??Сотрудник??6   $??Right=?6(   $??0,0,10,0q?6D   $??Center=?6V   ?? 5e      -   5        $ cmbEmployees??5e   '   $??1??6    ?? DisplayMemberPath$ Employee_Name??6=   5f      ? 5i   
   $??10??6    5j      ?? 5k      $	??100 ?6#   ?? 5l      ?? 5m      ?? 5n      .+?5p      ?? -   5        $??
Назад??5p      $??10,10,10,10q?6%   6:   ?? 5q      -	   5        $??Добавить??5q      $??10,10,10,10q?6(   $??1??6=   6M   ?? 5r      -
   5        $??Изменить??5r      $??10,10,10,10q?6(   $??2??6=   6M   ?? 5s      -   5        $??Удалить??5s      $??10,10,10,10q?6'   $??3??6<   6L   5t      5u      5v      