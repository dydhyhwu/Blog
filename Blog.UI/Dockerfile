# build stage
FROM node:lts-alpine as build-stage
WORKDIR /app
COPY . .
COPY /src/config/index.ts.docker ./src/config/index.ts
ARG VUE_APP_API_URL
ARG BUILD_MODE=ALL

ENV VUE_APP_API_URL $VUE_APP_API_URL
ENV BUILD_MODE $BUILD_MODE

RUN chmod +x /build/build.sh && \
    ./build/build.sh && \
    npm install && \
    npm run build

# production stage
FROM nginx:stable-alpine as production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"] 