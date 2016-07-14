reset=0
for((a=1;a<10000;a++))
do

if [ $reset -eq 10 ]; then
	rm /var/db/lsd/com.apple.lsdidentifiers.plist
	rm $(find //var/mobile/Applications -name 'Caches') -rf
	rm $(find //var/mobile/Applications -name 'Cookies') -rf
	let "reset = 0 "
fi


let "reset += 1 "
num=$((RANDOM%3))
app1=phuongnguyennew.Bird-Jump
app2=newphuongnt3003.Bug-Fighter
app3=phuongnt1999.Ladybug-Fighter
appname1="Bird Jump"
appname2="Bug Fighter"
appname3="Ladybug Fighter"
if [ $num -eq 0 ]; then
	open $app1
	sleep 60
	killall -m $appname1
else if [ $num -eq 1 ]; then
	open $app2
	sleep 60
	killall -m $appname2
else
	open $app3
	sleep 60
	killall -m $appname3
fi

fi
sleep 1
done