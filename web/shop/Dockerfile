FROM node:latest AS publish
WORKDIR /app

COPY ./web/shop/package.json ./web/shop/package-lock.json ./
RUN npm ci

COPY ./web/shop .
RUN npm run build



FROM node:latest as final
COPY --from=publish /app/package.json /app/publish ./

CMD ["node", "index.js"]
