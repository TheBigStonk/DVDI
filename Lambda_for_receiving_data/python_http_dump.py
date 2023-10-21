import json


def lambda_handler(event, context):
    query_string_params = event.get('queryStringParameters')
    print("Received victim information: ", json.dumps(query_string_params))

    response = {
        'statusCode': 200,
    }
