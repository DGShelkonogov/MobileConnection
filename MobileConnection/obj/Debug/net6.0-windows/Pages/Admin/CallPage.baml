   M S B A M L   `   `   `  ????K  GMobileConnection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:MobileConnection.Pages.AdminMobileConnection.Pages.Admin  5      +    %MobileConnection.Pages.Admin.CallPage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:MobileConnection.Pages.Admin     5        N? 
Background
  ????? N? Title$ CallPage??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??50 ?6   .+?5   
   ?  ? ColumnDefinitions 5      ?? 5      ?? 5      $	??100 ?6#   .+?5      ?? -   5         ??Name$ 	txbSearch??5       ?? TextWrapping$
 Wrap=?6)   $??10,10,10,10q?6=   ?? 5      -   5        $??1??5      $??
Поиск??6%   $??10,10,10,10q?66   6K   5      &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$	 dtg??5!      $??1??6       AutoGenerateColumns$ False??6-      Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Дата звонка??5&      
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 2* 5'      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5(      ??  ?? Path$ 	Call_Date? ?? UpdateSourceTrigger$ PropertyChanged=?  5+      $*	 $Время начала звонка??5,      $
 2* 5-       5.      ?? $ Call_Start_Time?$ PropertyChanged=?  51      $(	 "Продолжительность??52      $
 2* 53       54      ?? $ Duration?$ PropertyChanged=?  57      $8	 2Номер вызываемого абонента??58      $
 3* 59       5:      ?? $ Subscriber_Called_Number?$ PropertyChanged=?  5=      $	 Тип звонка??5>      $
 3* 5?       5@      ?? $ Type.Type_Name?$ PropertyChanged=?5C      ? 5E   
   $??2??6    5F      ?? 5G      ?? 5H      .+?5J      ?? $??Дата звонка??6   $??Right=?6*   $??0,0,10,0q?6F   $??Center=?6X   ?? 5K      -   5        $ tbxCall_Date??5K      $??1??6,   $
 Wrap=?6<   5L      ? 5N   
   $??3??6    5O      ?? 5P      ?? 5Q      .+?5S      ?? $*??$Время начала звонка??6   $??Right=?62   $??0,0,10,0q?6N   $??Center=?6`   ?? 5T      -   5        $ tbxCall_Start_Time??5T      $??1??62   $
 Wrap=?6C   5U      ? 5W   
   $??4??6    5X      ?? 5Y      ?? 5Z      .+?5\      ?? $(??"Продолжительность??6   $??Right=?60   $??0,0,10,0q?6L   $??Center=?6^   ?? 5]      -   5        $ tbxDuration??5]      $??1??6+   $
 Wrap=?6;   5^      ? 5`   
   $??5??6    5a      ?? 5b      ?? 5c      .+?5e      ?? $8??2Номер вызываемого абонента??6   $??Right=?69   $??0,0,10,0q?6U   $??Center=?6g   ?? 5f      -   5        $! tbxSubscriber_Called_Number??5f      $??1??6;   $
 Wrap=?6K   5g      ? 5j   
   $??6??6    5k      ?? 5l      ?? 5m      .+?5o      ?? $??Тип звонка??6   $??Right=?6)   $??0,0,10,0q?6E   $??Center=?6W   ?? 5p      -   5         ??Name$ cmbTypeCall??5p       ?? DisplayMemberPath$ 	Type_Name??6,   $??1??6J   5r      ? 5t   
   $??10??6    5u      ?? 5v      $	??100 ?6#   ?? 5w      ?? 5x      ?? 5y      .+?5{      ?? -	   5        $??
Назад??5{      $??10,10,10,10q?6%   6:   ?? 5|      -
   5        $??Добавить??5|      $??10,10,10,10q?6(   $??1??6=   6M   ?? 5}      -   5        $??Изменить??5}      $??10,10,10,10q?6(   $??2??6=   6M   ?? 5~      -   5        $??Удалить??5~      $??10,10,10,10q?6'   $??3??6<   6L   5      5?      5?      