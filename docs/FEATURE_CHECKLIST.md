# SkillBazaar Functional Requirement Checklist

This checklist maps the requirements in `Project_Report.pdf` to the completed
application.

| ID | Requirement | Implementation |
|---|---|---|
| FR1 | Super Admin login | `LoginForm` authenticates and routes the Super Admin role. |
| FR2 | Approve or reject instructor registrations | Overview and Manage Instructors tabs. |
| FR3 | Suspend or reactivate instructors | Manage Instructors tab updates both institute and user status. |
| FR4 | Moderate or delete courses | Course Moderation tab supports hide, restore, and safe deletion. |
| FR5 | Platform reports | Reports tab shows commission, instructor earnings, and best selling courses. |
| FR6 | Process payouts | Payout Requests tab validates balance and approves or rejects requests. |
| FR7 | Low rating monitoring | Reports tab lists courses below a 2.5 average rating. |
| FR8 | Instructor registration | Sign Up captures institute name, category, contact, and address. |
| FR9 | Approval restricted login | Pending and suspended accounts are blocked at login. |
| FR10 | Instructor course CRUD | Course CRUD tab. |
| FR11 | Course configuration | Price, seats, category, pricing type, duration, alert threshold, and visibility. |
| FR12 | View enrolled students | Enrolled Students tab. |
| FR13 | View 80 percent earnings | Overview and Earnings tabs calculate net earnings. |
| FR14 | Request payout | Earnings and Payouts tab. |
| FR15 | View ratings and reviews | Ratings and Reviews tab. |
| FR16 | Student registration and login | Sign Up and Login forms. |
| FR17 | Search courses | Course Catalog title and institute search. |
| FR18 | Filter courses | Category, minimum and maximum price, and minimum rating filters. |
| FR19 | Cart CRUD | Add, change quantity, and remove actions. |
| FR20 | Simulated checkout | bKash, Nagad, Card, and Cash with stored reference and invoice. |
| FR21 | Active discount offers | Offers are displayed and captured in cart, checkout, and order items. |
| FR22 | My Learning | Purchase history and enrolled course list. |
| FR23 | Purchased course reviews | Create or update review from My Learning only. |

## End to end verification path

1. Log in as Super Admin and approve the pending instructor.
2. Log in as the approved instructor, create a course, and add an offer.
3. Log in as the customer, filter for the course, open its details, and add it to the cart.
4. Change the quantity, check out, and confirm the invoice.
5. Submit a review from My Learning.
6. Return to the instructor to view the enrollment, review, earnings, and request a payout.
7. Return to Super Admin to approve the payout and inspect the reports.
