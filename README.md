# forked from https://github.com/flowerinthenight/ffmpeg-encode-h264mp4 / Aforge eample
# Overview

A sample x64 application written in C/C++/C# that generates bitmaps for h264 encoding (using mp4 as container) using [ffmpeg](https://www.ffmpeg.org/). ffmpeg's [`dev`](./ffmpeg-latest-win64-dev/) and [`shared`](./ffmpeg-latest-win64-shared/) packages are included. These packages were downloaded from [this location](https://ffmpeg.zeranoe.com/builds/win64/).

You need to copy ffmpeg's [bin](./ffmpeg-latest-win64-shared/bin/) files (`*.dll`) to the output directory of the C# project. This project is tested in [Debug|x64](./H264MP4Encode/bin/x64/Debug/) configuration so the bin files are already included there.

