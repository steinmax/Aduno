FROM nginx:alpine

COPY . /usr/share/nginx/html
COPY default.conf /etc/nginx/conf.d/default.conf

RUN "rm Dockerfile"
RUN "rm default.conf"

EXPOSE 80 443