url: https://localhost:5069

Target framework: .NET8.0

Test data:
```bash
curl -X 'POST' \
  'https://localhost:5069/api/GispGovRu/details' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "app": {
    "appId": "75de29d1-09f1-419e-aa17-e479c9f0f1c8",
    "appSecret": "dde5372b-5a1c-45ab-bf3e-f4b3a927a061"
  },
  "canLoadAttachments": true,
  "productLinks": [
    "https://gisp.gov.ru/goods/#/product/2621455"
  ]
}'
```

```bash
curl -X 'POST' \
  'https://localhost:5069/api/GosZakupki/search' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "app": {
    "appId": "3efe40f3-4446-4be2-9dea-32a21971f858",
    "appSecret": "28b8ee9e-a42b-4842-9b92-bc3bb19f8db6"
  },
  "searchPhraseList": [
    "ru"
  ],
  "waitTimeout": 0,
  "maxProductsCount": 0
}'
```
```bash
curl -X 'POST' \
  'https://localhost:5069/api/GosZakupki/details' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "app": {
    "appId": "3efe40f3-4446-4be2-9dea-32a21971f858",
    "appSecret": "28b8ee9e-a42b-4842-9b92-bc3bb19f8db6"
  },
  "canLoadAttachments": true,
  "productLinks": [
    "https://goszakupki.eaeunion.org/erpt/registers/vipiska/6582fb8ea4a4b05007bb43cb"
  ]
}'
```

```bash
curl -X 'POST' \
  'https://localhost:5069/api/ReestrDigitalGovRu/search' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "app": {
    "appId": "40b7f3a2-86a3-4d56-b25b-205b173dc933",
    "appSecret": "94fa1ec9-fd67-4d90-89d4-a84493631149"
  },
  "searchPhraseList": [
    "js"
  ],
  "waitTimeout": 0,
  "maxProductsCount": 0
}'
```

```bash
curl -X 'POST' \
  'https://localhost:5069/api/ReestrDigitalGovRu/details' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "app": {
    "appId": "40b7f3a2-86a3-4d56-b25b-205b173dc933",
    "appSecret": "94fa1ec9-fd67-4d90-89d4-a84493631149"
  },
  "canLoadAttachments": true,
  "productLinks": [
    "https://reestr.digital.gov.ru/reestr/1627905/?sphrase_id=5945755"
  ]
}'
```

Example output

```
{
  "variants": [
    {
      "phrase": "парсер",
      "products": [
        {
          "code": "",
          "name": "Сотбит: Парсер контента – сайты, excel, xml, yml, csv, rss",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/reestr/2992930/?sphrase_id=5945755",
          "catalogPath": ""
        },
        {
          "code": "",
          "name": "Парсер объявлений по продаже автомобилей",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/reestr/1627905/?sphrase_id=5945755",
          "catalogPath": ""
        },
        {
          "code": "",
          "name": "Консалтинговая онлайн-платформы для поступающих с возможностью оценки шансов на зачисление на основе интеллектуализированной системы поддержки принятия решений «Выбор будущего»",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/reestr/1834243/?sphrase_id=5945755",
          "catalogPath": ""
        },
        {
          "code": "",
          "name": "Защищенная IoT платформа сбора и обработки телеметрических данных",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/reestr/571482/?sphrase_id=5945755",
          "catalogPath": ""
        },
        {
          "code": "",
          "name": "Delta Solutions Mediation",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/reestr/2642790/?sphrase_id=5945755",
          "catalogPath": ""
        },
        {
          "code": "",
          "name": "Сотбит: Парсер контента – сайты, excel, xml, yml, csv, rss",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/request/2827808/?sphrase_id=5945755",
          "catalogPath": ""
        },
        {
          "code": "",
          "name": "Парсер объявлений по продаже автомобилей",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/request/1485947/?sphrase_id=5945755",
          "catalogPath": ""
        },
        {
          "code": "",
          "name": "Консалтинговая онлайн-платформы для поступающих с возможностью оценки шансов на зачисление на основе интеллектуализированной системы поддержки принятия решений «Выбор будущего»",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/request/1670085/?sphrase_id=5945755",
          "catalogPath": ""
        },
        {
          "code": "",
          "name": "Защищенная IoT платформа сбора и обработки телеметрических данных",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/request/516306/?sphrase_id=5945755",
          "catalogPath": ""
        },
        {
          "code": "",
          "name": "Delta Solutions Mediation",
          "price": 0,
          "priceCurrency": "RUB",
          "quantityCurrent": 0,
          "quantityInStock": 0,
          "link": "https://reestr.digital.gov.ru/request/2471813/?sphrase_id=5945755",
          "catalogPath": ""
        }
      ]
    }
  ],
  "app": {
    "appId": "40b7f3a2-86a3-4d56-b25b-205b173dc933",
    "appSecret": "94fa1ec9-fd67-4d90-89d4-a84493631149"
  }
}

===================================================================================================
{
  "products": [
    {
      "code": "6582fb8ea4a4b05007bb43cb",
      "name": "Бумага-основа для декоративных облицовочных материалов БО, БОфон, БОфон «гегенцуг», индекс цвета, массой 1 м2 от 48 г по 113 г, формат от 1750 мм по 2300 мм ",
      "price": 0,
      "priceCurrency": "RUB",
      "quantityCurrent": 0,
      "quantityInStock": 0,
      "link": "https://goszakupki.eaeunion.org/erpt/registers/vipiska/6582fb8ea4a4b05007bb43cb",
      "catalogPath": "",
      "properties": [
        {
          "name": "Id.Oid",
          "value": "6582fb8ea4a4b05007bb43cb"
        },
        {
          "name": "DocumentType",
          "value": "1"
        },
        {
          "name": "DocumentName",
          "value": "ТУ BY 790282162.011- 2015 Бумага-основа для декоративных облицовочных материалов. Технические условия"
        },
        {
          "name": "GoodsName",
          "value": "Бумага-основа для декоративных облицовочных материалов БО, БОфон, БОфон «гегенцуг», индекс цвета, массой 1 м2 от 48 г по 113 г, формат от 1750 мм по 2300 мм "
        },
        {
          "name": "ExpertActEndDate",
          "value": "2023-05-04"
        },
        {
          "name": "GoodsOkpd2",
          "value": "17.12.11.143"
        },
        {
          "name": "Tnved",
          "value": "4805 91 000 0"
        },
        {
          "name": "Region",
          "value": "35"
        },
        {
          "name": ".AttachmentId[0]",
          "value": "052041cb-2b50-4164-922e-1c135b16edd8"
        },
        {
          "name": "Points",
          "value": "0"
        },
        {
          "name": "IdentityCode",
          "value": "790282162"
        },
        {
          "name": "Name",
          "value": "РУП \"Завод газетной бумаги\""
        },
        {
          "name": "Address",
          "value": "Республика Беларусь, 213002, Могилевская обл., г. Шклов, ул.1-я Заводская, д. 9"
        },
        {
          "name": "StateMember",
          "value": "02"
        },
        {
          "name": "User",
          "value": "Жуковский Павел Васильевич (Заместитель директора Департамента конкурентной политики и политики в области государственных закупок Комиссии)"
        },
        {
          "name": "ApplicationItemStatus",
          "value": "7"
        },
        {
          "name": "RegistryNumber",
          "value": "000005846"
        },
        {
          "name": "PublishDate",
          "value": "2022-05-11 09:55:56"
        },
        {
          "name": "IndustrialId",
          "value": "38"
        }
      ],
      "images": [],
      "attachments": []
    }
  ],
  "app": {
    "appId": "3efe40f3-4446-4be2-9dea-32a21971f858",
    "appSecret": "28b8ee9e-a42b-4842-9b92-bc3bb19f8db6"
  }
}
```
