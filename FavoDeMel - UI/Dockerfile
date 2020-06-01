FROM node:alpine as angular-build

WORKDIR /app

COPY . ./

RUN npm set progress=false && npm set strict-ssl false && npm install

RUN npm run build -- --prod --output-path=./dist/out

FROM nginx:alpine

RUN rm -rf /usr/share/nginx/html/*
COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=angular-build /app/dist/out /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
