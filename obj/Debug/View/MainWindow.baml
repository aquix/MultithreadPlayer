   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   ? ;Lab7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab7Lab7 5   	   /clr-namespace:Lab7.ResourcesLab7.Resources 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 63   /clr-namespace:Lab7.ViewModelLab7.ViewModel 5   	      Lab7.View.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6(   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   $localclr-namespace:Lab7     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -resxclr-namespace:Lab7.Resources     5   	   6sys&clr-namespace:System;assembly=mscorlib     63   2	viewModelclr-namespace:Lab7.ViewModel     5   	     � Title$  
MainWindow��68   $	��525��6K   $	��350��6W    � DataContext 5
      (  "Lab7.ViewModel.MainWindowViewModel  5   
    � 	Resources 5      &  Lab7.ViewModel.DurationConverter   DurationConverter1 +Lab7.ViewModel.BooleanToVisibilityConverter   BooleanToVisibilityConverter2 ,Lab7.ViewModel.StateToButtonContentConverter ! StateToButtonContentConverter0 *Lab7.ViewModel.ListItemToSongInfoConverter  ListItemToSongInfoConverter��%t   &	        &	      &	 &     &	 9       5   
   6&     5   
   61     5   
   62     5   
   60   5      .��5      �  J� RenderTransformOrigin$ 0.497,0.483&�6   .+�5   
   �� -   5         ��Name$ btnPlay��5      $��36��6"   $��36��6-   $��245,267,0,0q�69   $
��Left=�6N   $	��Top=�5        StaticFlatButton#��[ 5      ��5      �� *TotalControlCommand+.��5      �� ��6   �� *	IsPlaying+ �� 	Converter# [ 5      �� 5   
   -   5        $ btnStop��5      $��36��6"   $��36��6-   $��286,267,0,0q�69   $
��Left=�6N   $	��Top=�5      #��[ 5      ��5      �� *StopCommand+.��5      �� $ ��/Resources/Images/stop.png��6   5      �� 5    
   -   5         ��Name$ listBox��5       $	��225��6#   $	��201��6/   $��
244,57,0,0q�6<   $
��Left=�6P   $	��Top=�5!       ^� BetweenShowDelay$
 1500��5#       ^� InitialShowDelay$
 1500��69   	 ^� ShowDuration$	 10000��5$      ��5"      �� *CurrentPlaylist+
 � ToolTip
 5%      _� 5&       6   ��  �� Path$ PlacementTarget� �� Self �� RelativeSource# Z .��5'      �� ��6    �� *SelectedItem+# [ 5(      ��5*      �� 5+      .R�5,      ]� $��36��6    $
��Left=�6,   ��.  .   (System.Windows.Interactivity.Interaction   Triggers 5-      /   )System.Windows.Interactivity.EventTrigger  5.         	EventName$ 	MouseMove��6-   .   (System.Windows.Interactivity.TriggerBase   Actions. 5/   "   6	   0System.Windows.Interactivity.InvokeCommandAction	   	  Command 68   ��  ��  �� AncestorType" �$( "DataContext.LstSongsMouseUpCommand� 	  CommandParameter 6�   ��  �� " ��50      .+�52      ]� $��36��6$   $��36��6/   $
��Left=�6;   .+�53      �� $��btnPlayItem��6%   $��25��68   $��25��6C   $��0q�6O     ButtonSizeAnimation#��[ 56   %   ��54   %   ��  �� " �$$ DataContext.ItemControlCommand���55   %   ��  �� " ��$ SelectedItem�.��57   "   �� ��6(   �� *	IsPlaying+# [ 58      59      �� 5:      $��txtDuration��6$   $��18��67   $��30,10q�6C   $��Right=�6R   ��5;   $   �� *
Duration+ �� Mode$ OneWay=�# [  �� 5<      $��txtTitle��6$   $	��100��64   $	��Top=�6@   ��5=   $   �� *Title+$ OneWay=��� 5>      $��tAuthor��6$   $	��100��63   $��Bottom=�6?   ��5?   $   �� *Author+$ OneWay=�5@      5A      5C      �� 5D   
   -   5        $ btnAddPlaylist��5D      $
��Auto��6)   $��36��66   $��	28,16,0,0q�6B   $
��Left=�6U   $	��Top=�5E      #��[ 5G      ��5F      �� *AddPlaylistCommand+.��5H      ��  �� Orientation$ 
Horizontal=�6   .+�5I      �� $��24��6   $��/Resources/Images/add.png��6#   �� 5J      $��Center=�6   ��67   �� *StringsViewModel.ADD_PLAYLIST+5K      5L      �� 5M   
   -   5        $ listBox1��5M      $	��142��6$   $	��150��60   $��	28,59,0,0q�6=   $
��Left=�6P   $	��Top=�5N      ��5O      �� *	Playlists+ �� SelectedItem 5P      �� *CurrentPlaylist+$ TwoWay=� 5Q        5R      $ MouseDoubleClick��6!   . 5S      	   6,   ��  �� " �$' !DataContext.RenamePlaylistCommand� 6�   ��  �� " ��$ SelectedItem�5T      ��5V      �� 5W      .R�5X      �� ��6    �� *Name+5Y      5[      ]� 5\   
   $��433,21,48,262q�6   .+�5]      �� -   5        $ addSongs��5]      $��25��6'   $��25��62   $��Center=�6>   $��Center=�6[   #��[ 5`      ��5^      �� *AddSongsCommand+��5_      �� .��5a      �� $��/Resources/Images/add.png��6   5b      5c      �� 5e   
   $	��142��6   $��58��6!   $��
28,214,0,0q�6-   $
��Left=�6A   $	��Top=�6\   $ 
Horizontal=�5f      .+�5g      �� -   5        $ btnSavePlaylist��5g      $��36��6.   $��36��69   $��30, 0q�6E   #��[ 5j      ��5h      �� *SavePlaylistCommand+��5i      �� .��5k      �� $ ��/Resources/Images/save.png��6   5l      �� 5m      -   5        $ btnLoadPlaylist��5m      $��36��6.   $��36��69   $��-20, 0q�6E   #��[ 5p      ��5n      �� *OpenPlaylistCommand+��5o      �� .��5q      �� $ ��/Resources/Images/open.png��6   5r      5s      �� 5t   
   $��36��6   $��36��6   $��
471,16,0,0q�6(   $
��Left=�6<   $	��Top=�6W   #��[ 5v      ��5u      �� *OpenSettingsCommand+.��5w      �� $$��/Resources/Images/settings.png��6   5x      �� 5y   
   -	   5         ��Name$ 	textBlock��5y      $��
244,26,0,0q�6'   $
��Left=�6;   $	��Top=�6V   $
��Wrap=�5z      ��5{      `� 5|       �� StringFormat$ {0} {1:00}:{2:00}:{3:00}��6   .1�5}      �� $( "StringsViewModel.PLAYLIST_DURATION�6   �� 5~      $$ CurrentPlaylist.Duration.Hours�6   �� 5      $&  CurrentPlaylist.Duration.Minutes�6   �� 5�      $&  CurrentPlaylist.Duration.Seconds�6   5�      5�      �� 5�   
   -
   5        $ 
textBlock1��5�      $��405,276,0,0q�6(   $
��Left=�6=   $	��Top=�6X   $
��Wrap=�5�      ��5�      `� 5�      $ {0} {1:#,#.0}��6   .1�5�      �� $" StringsViewModel.SONG_RATING�6   �� 5�      $ CurrentPlaylist.Rating�6   5�      5�      �� 5�   
   $��36��6   $��36��6   $��327,267,0,0q�6(   $
��Left=�6=   $	��Top=�6X   #��[ 5�      ��5�      �� *PlayPrevCommand+.��5�      �� $ ��/Resources/Images/prev.png��6   5�      �� 5�   
   $��36��6   $��36��6   $��368,267,0,0q�6(   $
��Left=�6=   $	��Top=�6X   #��[ 5�      ��5�      �� *PlayNextCommand+.��5�      �� $ ��/Resources/Images/next.png��6   5�      5�      5�      