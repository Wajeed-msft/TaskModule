﻿function getAdaptiveCard() {
    var card = {
        "type": "AdaptiveCard",
        "body": [
            {
                "type": "Container",
                "items": [
                    {
                        "type": "TextBlock",
                        "size": "Medium",
                        "weight": "Bolder",
                        "text": "Publish Adaptive Card schema"
                    },
                    {
                        "type": "ColumnSet",
                        "columns": [
                            {
                                "type": "Column",
                                "items": [
                                    {
                                        "type": "Image",
                                        "style": "Person",
                                        "url": "https://pbs.twimg.com/profile_images/3647943215/d7f12830b3c17a5a9e4afcc370e3a37e_400x400.jpeg",
                                        "size": "Small"
                                    }
                                ],
                                "width": "auto"
                            },
                            {
                                "type": "Column",
                                "items": [
                                    {
                                        "type": "TextBlock",
                                        "weight": "Bolder",
                                        "text": "Matt Hidinger",
                                        "wrap": true
                                    },
                                    {
                                        "type": "TextBlock",
                                        "spacing": "None",
                                        "text": "Created {{DATE(2017-02-14T06:08:39Z,SHORT)}}",
                                        "isSubtle": true,
                                        "wrap": true
                                    }
                                ],
                                "width": "stretch"
                            }
                        ]
                    }
                ]
            },
            {
                "type": "Container",
                "items": [
                    {
                        "type": "TextBlock",
                        "text": "Now that we have defined the main rules and features of the format, we need to produce a schema and publish it to GitHub. The schema will be the starting point of our reference documentation.",
                        "wrap": true
                    },
                    {
                        "type": "FactSet",
                        "facts": [
                            {
                                "title": "Board:",
                                "value": "Adaptive Card"
                            },
                            {
                                "title": "List:",
                                "value": "Backlog"
                            },
                            {
                                "title": "Assigned to:",
                                "value": "Matt Hidinger"
                            },
                            {
                                "title": "Due date:",
                                "value": "Not set"
                            }
                        ]
                    }
                ]
            }
        ],
        "actions": [
            {
                "type": "Action.ShowCard",
                "title": "Set due date",
                "card": {
                    "type": "AdaptiveCard",
                    "style": "emphasis",
                    "body": [
                        {
                            "type": "Input.Date",
                            "id": "dueDate"
                        },
                        {
                            "type": "Input.Text",
                            "id": "comment",
                            "placeholder": "Add a comment",
                            "isMultiline": true
                        }
                    ],
                    "actions": [
                        {
                            "type": "Action.Submit",
                            "title": "OK",
                            "data": {
                                "actester": true
                            }
                        }
                    ]
                }
            },
            {
                "type": "Action.OpenUrl",
                "title": "View",
                "url": "http://adaptivecards.io"
            }
        ],
        "version": "1.0"
    };
    return card;
};
