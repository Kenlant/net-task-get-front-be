# NetTaskGetFront

This probject was created as a test task solution .

## Main points

Project is written using clean architecutre pattern.
More information about setup and dependendencies you can find in project folders

## Suggestions

- To update database during query request is bad practce. I would separate these requests.
- polygon.io allows to get grouped result but I didn't use since it there is a requirement to calculate it
- I would send all tickers from client rather than storing some default configuration on a backend.
  Clients can have different needs so backend should be generic
- Post method was chosed since this request affects database. According to HTTP specification.
