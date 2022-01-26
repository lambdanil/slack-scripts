#!/usr/bin/python3
import os
import sys
import subprocess
blacklist = ["jdk","lua","jack2","jack"]
args = list(sys.argv)
args.remove(args[0])
package = args[0]
packages = str(subprocess.check_output(f"sbodeps {package}", shell=True ))
packages = packages.replace("b'","")
packages = packages.replace("'","")
packagelist = list(packages.split("\\n"))
packagelist.remove(packagelist[len(packagelist)-1])
for pkg in packagelist:
    if pkg in blacklist:
        packagelist.remove(pkg)
pkgs = (" ".join(packagelist))
os.system(f"si {pkgs}")
