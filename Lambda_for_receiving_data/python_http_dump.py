import json


def lambda_handler(event, context):
    query_string_params = event.get('queryStringParameters') or {}
    print("Received victim information: ", json.dumps(query_string_params))

    response = {
        'statusCode': 200,
        'headers': {
            'Content-Type': 'application/json'
        },
        'body': json.dumps({'message': 'Request received'})
    }

    return response
