   M S B A M L   `   `   `  ????K  GMobileConnection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MobileConnection.PagesMobileConnection.Pages  5      0    *MobileConnection.Pages.CorporateClientPage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:MobileConnection.Pages     5        N? 
Background
  ????? N? Title$ CorporateClientPage??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??50 ?6   ?? 5      ?? 5      $??50 ?6   .+?5   
   ?? $!??Личный кабинет??6   $??Center=?6)   $??Center=?6F   ? 5   
   $??1??6    ? ColumnDefinitions 5      ?? 5      ?? 5      .+?5      ?  5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5       ?? 5!      .+?5#      ?? $'??!Уникальные данные??6   $??Center=?64   $??Center=?6Q   ?? 5$      -   5         ??Name$ txbAccount_Number??5$      ${?False??65    ?? TextWrapping$
 Wrap=?6G   $??1??6[   $??10,10,10,10q?6h   ?? 5%      -   5        $ txbContract_Number??5%      ${?False??66   $
 Wrap=?6H   $??2??6\   $??10,10,10,10q?6i   ?? 5&      -   5        $! txbContract_Conclusion_Date??5&      ${?False??6?   $
 Wrap=?6Q   $??3??6e   $??10,10,10,10q?6r   ?? 5'      -   5        $ txbPhone_Number??5'      ${?False??63   $
 Wrap=?6E   $??4??6Y   $??10,10,10,10q?6f   ?? 5(      -   5        $ txbAmountServise??5(      ${?False??64   $
 Wrap=?6F   $??5??6Z   $??10,10,10,10q?6g   5)      ? 5+      $??1??6    5,      ?? 5-      ?? 5.      ?? 5/      ?? 50      ?? 51      ?? 52      .+?54      ?? $+??%Персональные данные??6   $??Center=?66   $??Center=?6S   ?? 55      -   5        $ txbINN??55      $
 Wrap=?6*   $??1??6>   $??10,10,10,10q?6K   ?? 56      -   5        $ txbCompany_Name??56      $
 Wrap=?63   $??2??6G   $??10,10,10,10q?6T   ?? 57      -   5        $ txbLegal_Adsress??57      $
 Wrap=?64   $??3??6H   $??10,10,10,10q?6U   ?? 58      -	   5        $ txbPhysical_Adsress??58      $
 Wrap=?67   $??4??6K   $??10,10,10,10q?6X   ?? 59      -
   5        $  txbPersonal_Account_Number??59      $
 Wrap=?6>   $??5??6R   $??10,10,10,10q?6_   5<      5>      ? 5A   
   $??2??6    5B      ?? 5C      ?? 5D      ?? 5E      .+?5G      ?? -   5        $+??%Управление услугами??5G      $??10,10,10,10q?63   6H   ?? 5H      -   5        $ ??Редактировать??5H      $??10,10,10,10q?6.   $??2??6C   6S   ?? 5I      -   5        $??
Выход??5I      $??10,10,10,10q?6&   $??1??6;   6K   5J      5K      5L      