#!/bin/bash
dir=`pwd`
cd Core/
msbuild
cp bin/Debug/Core.dll  /Users/wangxiaoguang/Desktop/workspace/unity/New\ Unity\ Project/Assets/Plugins/
cp bin/Debug/Core.pdb  /Users/wangxiaoguang/Desktop/workspace/unity/New\ Unity\ Project/Assets/Plugins/
cp bin/Debug/Core.xml  /Users/wangxiaoguang/Desktop/workspace/unity/New\ Unity\ Project/Assets/Plugins/
cd $dir
