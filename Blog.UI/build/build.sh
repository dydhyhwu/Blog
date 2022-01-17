cd ../

if [[ $BUILD_MODE = 'ALL' ]]; then
    cp -f src/router/all.ts src/router/index.ts

elif [[ $BUILD_MODE = 'WEB' ]]; then
    cp -f src/router/web.ts src/router/index.ts

elif [[ $BUILD_MODE = 'MANAGE' ]]; then
    cp -f src/router/admin.ts src/router/index.ts
fi