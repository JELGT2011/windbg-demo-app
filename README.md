windbg-demo-app
===============

A sample app in ASP.net MVC to demo using WinDbg to diagnose a hang. More info to come.

At a past workplace there was an internal app which was being built in Debug mode, but its global Application_Error() handler had a call to Debug.Assert(). In IIS6, Debug.Assert() would show a dialog box on the services desktop (also called "session 0"), which would hang the thread and thus the request.

A load balancer would request a particular URL once per minute, but because the site was misconfigured that request would respond with a 404. The 404 error triggered a call to Application_Error(), which would then call Debug.Assert() and hang.

What we found was only one dialog box could be shown at any one time, so every 404 request would hang waiting for the first dialog box to be cleared.

After enough 404 errors had occurred the site would have no threads left to handle requests and would stall requiring a recycle.

We found this by using WinDbg and SOS to inspect a memory dump of an IIS w3wp.exe process.

This is part of a demo for another workplace to warn them of the dangers of Debug.Assert().