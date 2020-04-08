from datetime import date


"""
Get formatted date for log.
"""
def getDate():
    return date.today().strftime("[%d/%m/%Y, %H:%M:%S]")
