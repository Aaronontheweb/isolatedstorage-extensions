if not exist Download mkdir Download
if not exist Download\packages mkdir Download\packages
if not exist Download\packages\IsolatedStorageExtensions mkdir Download\packages\IsolatedStorageExtensions
if not exist Download\packages\IsolatedStorageExtensions\lib mkdir Download\packages\IsolatedStorageExtensions\lib
if not exist Download\packages\IsolatedStorageExtensions\lib\sl4 mkdir Download\packages\IsolatedStorageExtensions\lib\sl4
if not exist Download\packages\IsolatedStorageExtensions\lib\sl4-wp71 mkdir Download\packages\IsolatedStorageExtensions\lib\sl4-wp71

copy LICENSE.txt Download\packages\IsolatedStorageExtensions

copy IsolatedStorageExtensions\bin\Release\IsolatedStorageExtensions.dll Download\packages\IsolatedStorageExtensions\lib\sl4
copy IsolatedStorageExtensions.Mobile\bin\Release\IsolatedStorageExtensions.Mobile.dll Download\packages\IsolatedStorageExtensions\lib\sl4-wp71

nuget.exe pack IsolatedStorageExtensions.nuspec -BasePath Download\packages\IsolatedStorageExtensions -OutputDirectory Download