import time, random, string
from locust import HttpUser, task, between

class LoadTestDemo(HttpUser):
    wait_time = between(1, 5)

    @task(3)
    def get_data(self):
        self.client.get("/GetData")
    
    @task
    def write_data(self):
        trid = ''.join(random.choices(string.ascii_letters + string.digits, k=16))
        cr = ''.join(random.choices(string.ascii_letters + string.digits, k=16))
        self.client.post("/WriteData?transactionId="+trid+"&clientRequestTime="+cr+"")

    def on_start(self):
         self.client.verify = False
