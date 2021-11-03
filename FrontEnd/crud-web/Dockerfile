FROM node:14-alpine as Angular
WORKDIR /app
COPY package.json /app
RUN npm install --silent
COPY . .
RUN npm run build

FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=angular app/dist/FrontEnd /usr/share/nginx/html
COPY ./config/nginx.conf /etc/nginx/conf.d/default.conf
