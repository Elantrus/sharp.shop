FROM node:latest
WORKDIR /app

COPY ./web/shop .

RUN npm install
RUN npm run build

CMD ["npm", "run", "preview"]
