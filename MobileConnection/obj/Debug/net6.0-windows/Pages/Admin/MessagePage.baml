   M S B A M L   `   `   `  ????K  GMobileConnection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:MobileConnection.Pages.AdminMobileConnection.Pages.Admin  5      .    (MobileConnection.Pages.Admin.MessagePage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:MobileConnection.Pages.Admin     5        N? 
Background
  ????? N? Title$ MessagePage??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??50 ?6   .+?5   
   ?  ? ColumnDefinitions 5      ?? 5      ?? 5      $	??100 ?6#   .+?5      ?? -   5         ??Name$ 	txbSearch??5       ?? TextWrapping$
 Wrap=?6)   $??10,10,10,10q?6=   ?? 5      -   5        $??1??5      $??
Поиск??6%   $??10,10,10,10q?66   6K   5      &   System.Windows.Controls.DataGrid  5    
   -   5          Name$	 dtg??5       $??1??6       AutoGenerateColumns$ False??6-      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn	   Header$!	 Дата сообщения??5%      
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 2* 5&      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5'      ??  ?? Path$ Message_Date? ?? UpdateSourceTrigger$ PropertyChanged=?  5*      $!	 Время отправки??5+      $
 2* 5,       5-      ?? $ Sending_Time?$ PropertyChanged=?  50      $!	 Номер абонента??51      $
 2* 52       53      ?? $ Subscriber_Number?$ PropertyChanged=?  56      $	 Тип звонка??57      $
 3* 58       59      ?? $ Type.Type_Name?$ PropertyChanged=?5<      ? 5>   
   $??2??6    5?      ?? 5@      ?? 5A      .+?5C      ?? $!??Дата сообщения??6   $??Right=?6-   $??0,0,10,0q?6I   $??Center=?6[   ?? 5D      -   5        $ tbxMessage_Date??5D      $??1??6/   $
 Wrap=?6@   5E      ? 5G   
   $??3??6    5H      ?? 5I      ?? 5J      .+?5L      ?? $!??Время отправки??6   $??Right=?6-   $??0,0,10,0q?6I   $??Center=?6[   ?? 5M      -   5        $ tbxSending_Time??5M      $??1??6/   $
 Wrap=?6@   5N      ? 5P   
   $??4??6    5Q      ?? 5R      ?? 5S      .+?5U      ?? $!??Номер абонента??6   $??Right=?6-   $??0,0,10,0q?6I   $??Center=?6[   ?? 5V      -   5        $ tbxSubscriber_Number??5V      $??1??64   $
 Wrap=?6D   5W      ? 5Y   
   $??5??6    5Z      ?? 5[      ?? 5\      .+?5^      ?? $.??(Тип звонка (сообщения)??6   $??Right=?65   $??0,0,10,0q?6Q   $??Center=?6c   ?? 5_      -   5         ??Name$ cmbTypeMessage??5_       ?? DisplayMemberPath$ 	Type_Name??6/   $??1??6M   5`      ? 5c   
   $??10??6    5d      ?? 5e      $	??100 ?6#   ?? 5f      ?? 5g      ?? 5h      .+?5j      ?? -   5        $??
Назад??5j      $??10,10,10,10q?6%   6:   ?? 5k      -	   5        $??Добавить??5k      $??10,10,10,10q?6(   $??1??6=   6M   ?? 5l      -
   5        $??Изменить??5l      $??10,10,10,10q?6(   $??2??6=   6M   ?? 5m      -   5        $??Удалить??5m      $??10,10,10,10q?6'   $??3??6<   6L   5n      5o      5p      