url: https://localhost:5069

Target framework: .NET8.0

Test data:

curl -X 'POST' \
  'https://localhost:5069/api/GosZakupki/search' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "app": {
    "appId": "3efe40f3-4446-4be2-9dea-32a21971f858",
    "appSecret": "28b8ee9e-a42b-4842-9b92-bc3bb19f8db6"
  },
  "searchPhraseList": ["трактор"],
  "waitTimeout": 0,
  "maxProductsCount": 0
}'

