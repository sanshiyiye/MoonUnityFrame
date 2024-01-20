#!/bin/bash
dir=`pwd`
cd Core/
msbuild
cp bin/Debug/Core.pdb  /Users/wangxiaoguang/Desktop/workspace/unity/Sample/Assets/Plugins/
cp bin/Debug/Core.xml  /Users/wangxiaoguang/Desktop/workspace/unity/Sample/Assets/Plugins/
cd $dir
