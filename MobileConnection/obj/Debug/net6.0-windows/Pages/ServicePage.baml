   M S B A M L   `   `   `  ????K  GMobileConnection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MobileConnection.PagesMobileConnection.Pages  5      (    "MobileConnection.Pages.ServicePage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:MobileConnection.Pages     5        N? 
Background
  ????? N? Title$ ServicePage??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??50 ?6   ?? 5      ?? 5      $??40 ?6   ?? 5      $??40 ?6   ?? 5      $??50 ?6   .+?5   
   ?? $+??%Управление услугами??6   $??Center=?6.   $??Center=?6K   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dtg??5      $??1??6       AutoGenerateColumns$ False??6-   ${?False??6I      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Услуга??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   ??  ?? Path$ Service_Name?	 ?? UpdateSourceTrigger$	 PropertyChanged=?  5      $ Цена??6%    5   %   ?? $
 Cost?$	 PropertyChanged=?  5      $ Статус??6%    5   %   ?? $ Service_Status?$	 PropertyChanged=?5"      ? 5$   
   $??2??6   
 ? ColumnDefinitions
 5%      ?? 5&      ?? 5'      .+?5)      ?? $#??Выберите услугу??6   $??Right=?6.   $??Center=?6J   ?? 5*      -   5         ??Name$ cmbServices??5*       ?? DisplayMemberPath$ Service_Name??6\   $??1??6}   $??10,10,10,10q?6?   5+      ? 5,   
   $??3??6   
 5-      ?? 5.      ?? 5/      .+?51      ?? $??Стоимость??6   $??Right=?6(   $??Center=?6D   ?? 52      -   5         ??Name$ 	lblAmount??52      $	??100??6'   $
??Left=?65   $??10,0,0,0q?6P   $??Center=?6b   $??1??6}   53      ? 55   
   $??4??6   
 56      ?? 57      $	??100 ?6#   ?? 58      ?? 59      .+?5;      ?? -   5        $??
Назад??5;      $??10,10,10,10q?6%   6:   ?? 5<      -   5        $??1??5<      $??Добавить??6%   $??10,10,10,10q?68   6M   ?? 5=      -   5        $??2??5=      $!??Удалить услугу??6%   $??10,10,10,10q?6>   6S   5?      5A      5B      