   M S B A M L   `   `   `  ????K  GMobileConnection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MobileConnection.PagesMobileConnection.Pages  5      )    #MobileConnection.Pages.RecoveryPage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:MobileConnection.Pages     5        N? 
Background
  ????? N? Title$ RecoveryPage??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5      .+?5   
   ?? $1??+Восстановление доступа??6   $??Center=?61   $??Center=?6N   ? 5   
   $??1??6    ? ColumnDefinitions 5      ?? 5      $??3* ?6#   ?? 5      $??5* ?6#   .+?5      ?? $??Email??6   $??Right=?6$   $??0,0,10,0q?6@   $??Center=?6R   ?? 5      -   5         ??Name$ txbEmail??5      $??1??6(   $??10,10,300,10q?68    ?? TextWrapping$
 Wrap=?6N   5      ?? 5   
   -   5        $??Подтвердить??5      $??2??6'   $??300,10,300,10q?64   $	??200??6i   ?? 5    
   $??Секретный код??6   $??Center=?6(   $??Center=?6E   $??3??6`   ?? 5!   
   -   5        $ txbKey??5!      $??4??6"   $
 Wrap=?6/   $??250,10,250,10q?6C   ?? 5"   
   -   5        $??Вход??5"      $??5??6    $??300,10,300,10q?6-   $	??200??6_   ?? 5#   
   -   5        $??
Назад??5#      $
??Left=?6!   $??10,10,10,10q?6<   $??6??6Q   $??Bottom=?6^   $??30??6y   $??50??6?   6?   5'      5(      