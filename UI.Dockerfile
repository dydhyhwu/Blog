# build stage
FROM node:lts-alpine as build-stage
WORKDIR /app
RUN npm install --registry=https://registry.npm.taobao.org
COPY . .
COPY /src/config/index.ts.docker ./src/config/index.ts
ARG VUE_APP_API_URL
ENV VUE_APP_API_URL $VUE_APP_API_URL
RUN npm run build

# production stage
FROM nginx:stable-alpine as production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"] 