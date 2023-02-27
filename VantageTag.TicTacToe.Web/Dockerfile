FROM node:18-alpine as build

RUN mkdir -p /app
WORKDIR /app

COPY package.json /app
RUN npm install

COPY . /app
RUN npm run build --prod

FROM nginx:1.17.1-alpine

COPY --from=build /app/dist/vantage-tag.tic-tac-toe.web /usr/share/nginx/html
#COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]